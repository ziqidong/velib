using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
//using System.ServiceModel.Web;

namespace Host
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract(SessionMode = SessionMode.Required, Name = "IService1")]
    public interface IService1
    {
        [OperationContract]
        string DoWork(int id);

        //[OperationContract]
        //Person GetData(String id);

        [OperationContract]
        string Getcitys();

        [OperationContract]
        string GetOneCity(string id);

        [OperationContract]
        string GetStation(string id);

        [OperationContract]
        int ClientQuantity();

        [OperationContract]
        int ClientRequestQuantity();

        [OperationContract]
        void SetRequestDelay(int delay);

        [OperationContract]
        string GetAverageRequestDelay();
    }
    
    [ServiceContract(SessionMode = SessionMode.Required, Name = "wcf")]
    public interface wcf {
        [OperationContract]
        string hehe();
    }

    [ServiceContract(CallbackContract = typeof(ICalcServiceEvents))]
    public interface ICalcServiiiiiiiiiiice
    {
        [OperationContract]
        void SendInfo(string name);

        [OperationContract]
        void SubscribeSentEvent();

        [OperationContract]
        void SubscribeSendFinishedEvent();
    }

    public interface ICalcServiceEvents
    {
        [OperationContract(IsOneWay = true)]
        void Sent(string name);

        [OperationContract(IsOneWay = true)]
        void SentFinished();
    }


}
