using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Models;
using Newtonsoft.Json;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        BindingList<Car> cars = new BindingList<Car>();

        public Form1()
        {
            InitializeComponent();
        }
    
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _ = LoadCarsFromApiAsync();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cars.Add(new Car
            {
                Id = cars.Count + 1,
                Brand = txtBrand.Text,
                Model = txtModel.Text
            });
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridCars.CurrentRow == null) return;

            Car selected = (Car)dataGridCars.CurrentRow.DataBoundItem;
            selected.Id = int.Parse(txtId.Text);
            selected.Brand = txtBrand.Text;
            selected.Model = txtModel.Text;

            dataGridCars.Refresh();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridCars.CurrentRow == null) return;

            Car selected = (Car)dataGridCars.CurrentRow.DataBoundItem;
            cars.Remove(selected);
        }

        private async Task LoadCarsFromApiAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:5001/api/cars");
                var json = await response.Content.ReadAsStringAsync();
                var carList = JsonConvert.DeserializeObject<List<Car>>(json);
                if (carList != null)
                {
                    cars = new BindingList<Car>(carList);
                    dataGridCars.DataSource = cars;
                }
            }
        }
    }
}
