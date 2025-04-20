

using  System.Windows.Forms;

namespace EventDrivenApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //attach event handlers with the form for events
            this.Load += new EventHandler(Form1_Load);
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
        }


        //event handler for mouse click
        private void Form1_MouseDown(object? sender, MouseEventArgs e)
        {
            this.Text = $"Event Driven Application: Mouse Clicked at ({e.X}, {e.Y})";
        }

        //event handler for form load
        private void Form1_Load(object? sender, EventArgs e)
        {
             this.Text = "Event Driven Application: form Loaded";
        }
    }
}
