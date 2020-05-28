using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using FreshMvvm;
using PropertyChanged;
using RIB.XamarinExamples.Models;
using RIB.XamarinExamples.Services;
using Xamarin.Forms;

namespace RIB.XamarinExamples.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class MyTablePageModel : FreshBasePageModel
    {
        private readonly IDataService _service;

        public MyTablePageModel(IDataService s)
        {
            _service = s;
        }
        public override void Init(object initData)
        {
            base.Init(initData);
            GetCustomers();
        }

        private async void GetCustomers()
        {
            try
            {
                var result = await _service.GetCustomers();
                Customers = result?.Any() ?? false
                    ? new ObservableCollection<Customer>(result)
                    : new ObservableCollection<Customer>();
            }
            catch (Exception e)
            {
                //Do something
            }
        }

        public Command DeleteCmd => new Command(async (id) =>
        {
            await Task.Delay(100);
            if (id != null)
            {
                var list = Customers.ToList();
                var customer = list.First(c => c.Id.Equals(id));
                list.Remove(customer);

                Customers = new ObservableCollection<Customer>(list);
            }
        });

        public ObservableCollection<Customer> Customers { get; set; }
    }
}
