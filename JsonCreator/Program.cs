using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
namespace JsonCreator
{
    class Program
    {
        private static string address = @"C:\Users\miron\source\repos\ConsoleApp1\ConsoleApp1";
        class DescriptionSet
        {
            public string key { get; set; }
            public string body { get; set; }

            public string GetKey()
            {
                return (key);
            }
            public string GetBody()
            {
                return (body);
            }

        }
        class CommandSet
        {
            public string key { get; set; }
            public string body { get; set; }

            public string GetKey()
            {
                return (key);
            }
            public string GetBody()
            {
                return (body);
            }
        }

        class JsonSender
        {
            public List<Object> dataList { get; set; }

            public List<Object> ReturnList()
            {
                return (dataList);
            }
            public List<Object> AddData(Object data)
            {
                dataList.Add(data);
                return (dataList);
            }
            public void SendData (string filename)
            {
                string output = JsonConvert.SerializeObject(dataList);
                File.WriteAllText(address+filename, output);

            }
        }


        static void Main(string[] args)
        {
            DescriptionSet First = new DescriptionSet
            {
                key = "транзистор",
                body = "Hадиоэлектронный компонент из полупроводникового материала, обычно с тремя выводами, способный небольшим входным сигналом управлять значительным током в выходной цепи, " +
    "что позволяет использовать его для усиления, генерирования, коммутации и преобразования электрических сигналов"
            };
            DescriptionSet Second = new DescriptionSet
            {
                key = "резистор",
                body = "Пассивный элемент электрических цепей, обладающий определённым или переменным значением электрического сопротивления, предназначенный для линейного преобразования силы тока в напряжение и напряжения в силу тока, " +
                "ограничения тока, поглощения электрической энергии и др. Весьма широко используемый компонент практически всех электрических и электронных устройств."
            };
            DescriptionSet Third = new DescriptionSet
            {
                key = "кварцевый резонатор",
                body = "Электронный прибор, в котором пьезоэлектрический эффект и явление механического резонанса используются для " +
                "построения высокодобротного резонансного элемента электронной схемы."
            };

            JsonSender NewSender = new JsonSender { dataList = new List<Object>() };
            NewSender.AddData(First);
            NewSender.AddData(Second);
            NewSender.AddData(Third);
            NewSender.SendData(@"\description.json");
            NewSender.ReturnList();
            List<DescriptionSet> dataList = JsonConvert.DeserializeObject<List<DescriptionSet>>(File.ReadAllText(address + @"\description.json"));
            foreach (DescriptionSet n in dataList)
            {
                Console.WriteLine(n.GetBody());
            }
            Console.WriteLine("stpo");
        }
    }
}
