using HuiJinYun.Domain.Entity.Device;
using HuiJinYun.Domain.Enum;
using HuiJinYun.Domain.Infrastructure.Common;
using HuiJinYun.Domain.Infrastructure.Port;
using HuiJinYun.Domain.Log;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HuiJinYun.Domain.Entity
{
    public class HuiJinYunProductionLine : IProductionLine
    {
        protected Func<IProductionContext, Task<bool>> _program;
        public Dictionary<string, PlcDeviceBase> Devices { get; set; } = new Dictionary<string, PlcDeviceBase>();
        public List<IProductionStage> Stages { get; set; } = new List<IProductionStage>();
        public List<IAGV<eHuiJinYunAGVState, eHuiJinYunStagePosition>> AGVs { get; set; } = new List<IAGV<eHuiJinYunAGVState, eHuiJinYunStagePosition>>();
        public int Count { get; set; } = 0;
 
        public HuiJinYunProductionLine() {
            
        }

        public void LoadConfig(string path)
        {
            StreamReader sr = new StreamReader(path);
            var config = (JObject)JsonConvert.DeserializeObject(sr.ReadToEnd());
            sr.Close();

            JToken token;
            if(config.TryGetValue("AGVConfig", out token))
            {
                ISerialize serialize = new ProtoClass();
                foreach (JObject t in token.Values())
                {
                    try
                    {
                        IPort port = new TcpPort(t.Value<string>("port"));
                        //var test = $"HuiJinYun.Domain.Entity.Device.{t.Value<string>("type")}AGV<TState, TPosition>";
                        Type type = Type.GetType($"HuiJinYun.Domain.Entity.Device.{t.Value<string>("type")}AGV`2");
                        type = type.MakeGenericType(typeof(eHuiJinYunAGVState), typeof(eHuiJinYunStagePosition));
                        object[] @params = new object[] { port, serialize };
                        @params = @params.Concat(buildParams(type, t.Value<JObject>("options"))).ToArray<object>();
                        var agv = (IAGV< eHuiJinYunAGVState, eHuiJinYunStagePosition>)Activator.CreateInstance(type, @params);
                        AGVs.Add(agv);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            if (config.TryGetValue("DeviceConfig", out token))
            {
                ISerialize serialize = new ProtoClass();
                foreach (JObject t in token.Values())
                {
                    try
                    {
                        var port = PortFactory.NewPort(t.Value<string>("port"));
                        Type type = Type.GetType($"HuiJinYun.Domain.Entity.Device.{t.Value<string>("type")}Device");
                        var device = (PlcDeviceBase)Activator.CreateInstance(type, port, serialize);
                        Devices.Add(((JProperty)t.Parent).Name, device);
                    }
                    catch(Exception ex)
                    {
                        continue;
                    }
                }
            }
            if (config.TryGetValue("StageConfig", out token))
            {
                foreach (var t in token.Values())
                {
                    try
                    {
                        List<IDevice> deviceList = new List<IDevice>();
                        foreach(var d in t["Device"].Values<string>())
                        {
                            deviceList.Add(Devices[d]);
                        }

                        Type type = Type.GetType($"HuiJinYun.Domain.Entity.{((JProperty)t.Parent).Name}Stage");
                        var stage = (IProductionStage)Activator.CreateInstance(type, deviceList.ToArray());
                        Stages.Add(stage);
                    }
                    catch(Exception ex)
                    {
                        continue;
                    }
                }
            }

            object[] buildParams(Type type, JObject joParams)
            {
                if (null == joParams)
                    return new object[0];
                else
                {
                    object[] @params = new object[joParams.Count];
                    List<JProperty> jpParams = new List<JProperty>(joParams.Properties());
                    for (var i = 0; i < jpParams.Count; i++)
                    {
                        @params[i] = jpParams[i].Value.Value<string>();
                    }
                    return @params;
                }
            }
        }

        public IProductionLine Program(Func<IProductionContext, Task<bool>> func)
        {
            _program = func;
            return this;
        }

        public IProductionLine Start(int mode = 0)
        {
            foreach (var agv in AGVs)
            {
                Task.Run(async () =>
                {
                    var context = new HuiJinYunProductionContext(this, agv);
                    var bLoop = true;
                    while (bLoop)
                    {
                        await context.Initial();
                        bLoop = await _program(context);
                        //agv.Goto(eHuiJinYunStagePosition.Finish);
                        lock (this) Count++;
                    }
                });
            }
            return this;
        }

        public IProductionLine Pause(int mode)
        {
            return this;
        }

        public IProductionLine Stop(int mode)
        {
            return this;
        }
    }
}
