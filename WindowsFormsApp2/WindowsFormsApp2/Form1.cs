using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Models;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private readonly HttpClient client = new HttpClient { BaseAddress = new Uri("https://localhost:5211/") };
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

        private async Task LoadCarsFromApiAsync()
        {
            var response = await client.GetAsync("api/cars");
            var json = await response.Content.ReadAsStringAsync();
            var carList = JsonConvert.DeserializeObject<List<Car>>(json);
            if (carList != null)
            {
                cars = new BindingList<Car>(carList);
                dataGridCars.DataSource = cars;
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var car = new Car
            {
                Brand = txtYear.Text,
                Model = txtModel.Text
            };
            var json = JsonConvert.SerializeObject(car);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/cars", content);
            if (response.IsSuccessStatusCode)
                await LoadCarsFromApiAsync();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridCars.CurrentRow == null) return;
            var car = (Car)dataGridCars.CurrentRow.DataBoundItem;
            car.Brand = txtYear.Text;
            car.Model = txtModel.Text;

            var json = JsonConvert.SerializeObject(car);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PutAsync($"api/cars/{car.Id}", content);
            await LoadCarsFromApiAsync();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridCars.CurrentRow == null) return;
            var car = (Car)dataGridCars.CurrentRow.DataBoundItem;
            await client.DeleteAsync($"api/cars/{car.Id}");
            await LoadCarsFromApiAsync();
        }

        private void dataGridCars_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridCars.CurrentRow == null) return;
            var car = (Car)dataGridCars.CurrentRow.DataBoundItem;
            txtYear.Text = car.Brand;
            txtModel.Text = car.Model;
        }

        private void txtModel_TextChanged(object sender, EventArgs e)
        {
            if (dataGridCars.CurrentRow == null) return;
            var car = (Car)dataGridCars.CurrentRow.DataBoundItem;
            car.Model = txtModel.Text;
            dataGridCars.Refresh();
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            if (dataGridCars.CurrentRow == null) return;
            var car = (Car)dataGridCars.CurrentRow.DataBoundItem;
            if (int.TryParse(txtYear.Text, out int year))
            {
                car.Year = year;
                dataGridCars.Refresh();
            }
        }
    }

    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }
}
