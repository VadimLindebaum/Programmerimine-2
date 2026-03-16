namespace KooliProjekt.WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class Car
        {
        }
        public int Id { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        List<Car> cars = new List<Car>();
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        dataGridView1.DataSource = cars; 
private void btnAdd_Click(object sender, EventArgs e)
        {
        }
        Car car = new Car();
        car.Id = cars.Count + 1; 
car.Model = txtModel.Text; 
car.Year = int.Parse(txtYear.Text);
        cars.Add(car); 
dataGridView1.DataSource = null; 
dataGridView1.DataSource = cars; 
private void btnUpdate_Click(object sender, EventArgs e)
        {
        }
        int index = dataGridView1.CurrentCell.RowIndex;
        cars[index].Model = txtModel.Text; 
cars[index].Year = int.Parse(txtYear.Text);
        dataGridView1.Refresh(); 
private void btnDelete_Click(object sender, EventArgs e)
        {
        }
        int index = dataGridView1.CurrentCell.RowIndex;
        cars.RemoveAt(index); 
dataGridView1.DataSource = null; 
dataGridView1.DataSource = c
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
