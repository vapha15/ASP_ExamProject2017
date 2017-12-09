﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class XMLSerialization
    {
        List<Persons> personList;
        List<SerialNumbers> persoList;

        //Remember to change the FilePath to a path that exist in your pc
        // private string XMLFileNamePersons = "C:\\Users\\Nam\\documents\\visual studio 2017\\Projects\\WebApplication1\\WebApplication1\\Files\\PersonListXML.xml";
        // private string XMLFileNameSerialNumbers = "C:\\Users\\Nam\\documents\\visual studio 2017\\Projects\\WebApplication1\\WebApplication1\\Files\\SerialNumberListXML.xml";
        private string XMLFileNameSerialNumbers = Path.GetFullPath("Files\\SerialNumberListXML.xml");
        private string XMLFileNamePersons = Path.GetFullPath("Files\\PersonListXML.xml");

        private XmlSerializer serializer;
        public void Serialize<T>(List<T> list, String fileName)
        {
            if (list == null) { return; }

            try
            {
                XmlDocument xmldoc = new XmlDocument();

                serializer = new XmlSerializer(list.GetType());

                using (FileStream stream = new FileStream(fileName, FileMode.Create))
                {
                    serializer.Serialize(stream, list);
                    stream.Position = 0;
                    xmldoc.Load(stream);
                    xmldoc.Save(fileName);
                    stream.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);

            }



        }


        public List<T> Deserialize<T>(String fileName)
        {
            var itemList = new List<T>();
            serializer = new XmlSerializer(typeof(List<T>));
            if (!File.Exists(fileName))
            {
                return itemList;
            }

            try
            {
                //XmlDocument xmldoc = new XmlDocument();
                using (FileStream stream = new FileStream(fileName, FileMode.Open))
                {
                    itemList = (List<T>)serializer.Deserialize(stream);

                }

            }

            catch (Exception e)
            {

            }
            return itemList;

        }


        public string GetXMLPersonListFileName()
        {
            return XMLFileNamePersons;
        }

        public string GetXMLSerialNumberListFileName()
        {
            return XMLFileNameSerialNumbers;
        }
    }
}

