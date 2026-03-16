using System.Collections;

namespace KooliProjekt.WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            dataGridCars.DataSource = new ArrayList
            {
                new { Id = 1, Make = "Toyota", Model = "Camry", Year = 2020 },
                new { Id = 2, Make = "Honda", Model = "Civic", Year = 2019 },
                new { Id = 3, Make = "Ford", Model = "Mustang", Year = 2021 }
            };


            base.OnLoad(e);
        }
    }
}
