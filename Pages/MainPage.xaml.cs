using AXADIO.Interpreter;

namespace AXADIO.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();  // XAML'dagi barcha elementlar shu yerda initsializatsiya qilinadi
        }

        public void OnCompilePressed(object sender, EventArgs e)
        {
            string compildecode = kodMaydoni.Text;  // 'kodMaydoni' XAML faylida aniqlangan bo‘lishi kerak
            string[] qatorlar = compildecode.Split("\n");
            StringParser stringParser = new StringParser();
            string natija = stringParser.Compile(qatorlar);
            myLabel.Text = natija;  // 'myLabel' XAML faylida aniqlangan bo‘lishi kerak
        }
    }
}
