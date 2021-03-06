﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebApiLab.Models;

namespace WebApi.ClientApp
{
    //*package:Microsoft.AspNet.WebApi.Client
    public partial class Form1 : Form
    {
        HttpClient client = new HttpClient();
        public Form1()
        {
            client.BaseAddress = new Uri("http://localhost:3752");
            client.DefaultRequestHeaders.Add("API_KEY", "KIMX-INFO-API-KEY");
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            GetAll();
        }

        private void GetAll()
        {
            HttpResponseMessage resp = client.GetAsync("api/products").Result;
            resp.EnsureSuccessStatusCode();
            var products = resp.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            MessageBox.Show(products.Count().ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var resp = client.GetAsync(string.Format("api/products/{0}", 1)).Result;
            resp.EnsureSuccessStatusCode();
            var product = resp.Content.ReadAsAsync<Product>().Result;
            MessageBox.Show(product.Name);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = string.Format("api/products?category={0}", "TAIFEI");
            var resp = client.GetAsync(query).Result;
            resp.EnsureSuccessStatusCode();
            var products = resp.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            MessageBox.Show(products.Count().ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            p.Name = "Post Name";
            p.Id = 999;
            p.Price = 100;
            var resp = client.PostAsJsonAsync("api/products", p).Result;
            resp.EnsureSuccessStatusCode();
            int effect = resp.Content.ReadAsAsync<int>().Result;
            GetAll();
        }

        private void btnPut_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            p.Name = "Put Name";
            p.Id = 1;
            p.Price = 100;
            var resp = client.PutAsJsonAsync("api/products/" + p.Id, p).Result;
            resp.EnsureSuccessStatusCode();
            GetAll();
        }


    }
}
