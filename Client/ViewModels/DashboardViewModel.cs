namespace Client.ViewModels
{
    public class DashboardViewModel
    {
        public DashboardViewModel()
        {
            Watches = new List<WatchViewModel>();
        }
        public List<WatchViewModel> Watches { get; set; }
        public string SortValue { get; set; }
    }
}
