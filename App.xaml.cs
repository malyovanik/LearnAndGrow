using LearnAndGrow.Model;
using LearnAndGrow.ViewModel;
using System.Windows;

namespace LearnAndGrow
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            LearnAndGrowView view = new LearnAndGrowView();
            LearnAndGrowModel model = new LearnAndGrowModel();
            LearnAndGrowViewModel viewModel = new LearnAndGrowViewModel(model);
            view.DataContext = viewModel;
            view.Show();
        }
    }
}