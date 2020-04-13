﻿using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace lab1_NguyenTuanAnh
{
    public class Data
    {
        private static Data instance;

        public static Data Instance { get { if (instance == null) instance = new Data(); return Data.instance; } private set { instance = value; } }

        private Data() { }

        public List<UserInfor> LoadData()
        {
            List<UserInfor> listUser = new List<UserInfor>();

            DataTable data = new DataTable();
            using(CsvReader csv = new CsvReader(new StreamReader(File.OpenRead("data.csv")),true))
            {
                data.Load(csv);
            }

            for (int i = 0; i <data.Rows.Count; i++)
            {
                if (data.Rows[i][1].ToString()== "915783624" || data.Rows[i][2].ToString()== "915783624")
                {
                    listUser.Add(new UserInfor
                    {
                        Timestamp = data.Rows[i][0].ToString(),
                        Msisdn_origin = data.Rows[i][1].ToString(),
                        Msisdn_des = data.Rows[i][2].ToString(),
                        Call_duration = Convert.ToDouble(data.Rows[i][3]),
                        Sms_number = Convert.ToInt32(data.Rows[i][4])
                    });
                }
            }
            return listUser;
        }

        public double PayOutCall(List<UserInfor> listUser)
        {
            double money = 0;
            foreach (UserInfor item in listUser)
            {
                if (item.Msisdn_origin== "915783624")
                {
                    if (item.Call_duration>10)
                    {
                        money = (item.Call_duration - 10) * 1;
                    }
                }
            }

            return money;
        }



        public double PaySms(List<UserInfor> listUser)
        {
            double money=0;
            foreach (UserInfor item in listUser)
            {
                if (item.Msisdn_origin == "915783624")
                {
                    money = item.Sms_number * 5;
                }
            }

            return money;
        }
    }
}
