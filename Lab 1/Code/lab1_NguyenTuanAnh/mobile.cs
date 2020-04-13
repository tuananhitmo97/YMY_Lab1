﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1_NguyenTuanAnh
{
    public partial class mobile : Form
    {
        public mobile()
        {
            InitializeComponent();
            loadData();
        }

        void loadData()
        {
            List<UserInfor> listUser = new List<UserInfor>();
            listUser = Data.Instance.LoadData();
            dataGridViewUser.DataSource = listUser;

            //тармфикация
             CultureInfo cultureRu = new CultureInfo("ru-RU");
            Thread.CurrentThread.CurrentCulture = cultureRu;
             Data.Instance.PayOutCall(listUser).ToString("c");

            textBoxOutCall.Text = Data.Instance.PayOutCall(listUser).ToString("c");
            textBoxIncomingCall.Text = "0";
            textBoxSms.Text = Data.Instance.PaySms(listUser).ToString("c");

            textBoxTotal.Text = (Convert.ToDouble(Data.Instance.PayOutCall(listUser).ToString()) +
                Convert.ToDouble("0") +
                Convert.ToDouble(Data.Instance.PaySms(listUser).ToString())).ToString("c");


        }

       
 
    }
}
