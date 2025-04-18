using AXADIO.Interpreter;

namespace AXADIO
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public void OnCompilePressed(object sender, EventArgs e)
        {
            string compildecode = kodMaydoni.Text;
            string[] qatorlar = compildecode.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            StringParser stringParser = new StringParser();
            string natija = stringParser.Compile(qatorlar);
            myLabel.Text = natija;
        }
    }

}
