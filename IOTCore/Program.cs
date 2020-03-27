using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using uPLibrary.Networking.M2Mqtt;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using System.Timers;
using uPLibrary.Networking.M2Mqtt.Messages;


namespace IOTCore
{
    class Program
    {

        private static System.Timers.Timer aTimer;
        
        static void Main(string[] args)
        {
            
            MqttClient client = new MqttClient("broker.hivemq.com");
            client.MqttMsgPublishReceived += ClientMqttMsgPublishReceived;
            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);
            client.Subscribe(new string[] {"/gw/ac233fc0514a/status"}, new byte[] {MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE});
            SetTimer();
            
            static void ClientMqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e) 
            { 
                aTimer.Stop();
                aTimer.Dispose();
                
                var values = Encoding.Default.GetString(e.Message);
                
                var objectList = Deserializer.DeserializedToList<BeaconData>(values);
                
                Console.WriteLine(values);
            }
        }
        
        private static void SetTimer()
        {
            aTimer = new System.Timers.Timer(3000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("No gateways are currently sending signals. " + e.SignalTime);
        }
        
    }
}