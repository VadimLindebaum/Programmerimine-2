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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        BindingList<Car> cars = new BindingList<Car>();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridCars.DataSource = cars;
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
    }
}
using HttpClient client = new HttpClient();
var response = await client.GetAsync("https://localhost:5001/api/cars");
var json = await response.Content.ReadAsStringAsync();
var cars = JsonSerializer.Deserialize<List<Car>>(json);
dataGridCars.DataSource = new BindingList<Car>(cars);
    }
}
