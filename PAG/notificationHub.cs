using Microsoft.AspNet.SignalR;

namespace SEFIN_TEMASIAFI
{
    public class notificationHub : Hub
    {
        public void SendMessage(string message)
        {
            Clients.Others.newMessage(message);
        }
        public void JoinGroup(string group, string message)
        {
            Groups.Add(Context.ConnectionId, group);
            Clients.OthersInGroup(group).newMessage(message);
        }
        public void SendMessageToGroup(string group, string message)
        {
            Clients.OthersInGroup(group).newMessage(message);
        }
        //public override Task OnDisconnected(bool stopCalled)
        //{
        //    SendMonitoringData("Disconnected", Context.ConnectionId);
        //    return base.OnDisconnected(stopCalled);
        //}
        //public override Task OnConnected()
        //{
        //    SendMonitoringData("Connected", Context.ConnectionId);
        //    return base.OnConnected();
        //}
        //public override Task OnReconnected()
        //{
        //    SendMonitoringData("Reconnected", Context.ConnectionId);
        //    return base.OnReconnected();
        //}
        //private void SendMonitoringData(string eventType, string connectionId)
        //{
        //    var context = GlobalHost.ConnectionManager.GetHubContext<MonitorHub>();

        //    context.Clients.All.NewEvent(eventType, connectionId);
        //}
        //private void SendMessage3(string message)
        //{
        //    //Enviar un mensaje a quien llama el metodo
        //    //Actually calling the sendMessage method on the client
        //    Clients.Caller.sendMessage(message);
        //    //Bellow call is same as before
        //    Clients.Client(this.Context.ConnectionId).sendMessage(message);
        //    //Sends to everybody including caller
        //    Clients.All.sendMessage(message);
        //    //Every one besides the caller
        //    Clients.Others.sendMessage(message);
        //    //same as before
        //    Clients.AllExcept(new string[] { Context.ConnectionId });
        //}


    }
}