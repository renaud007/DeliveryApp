using DeliveryApp.Models;
using DeliveryApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace DeliveryApp.ViewModels
{
   public class OrderHistoryViewModel : BaseViewModel
    {
        public ObservableCollection<OrderHistory> OrdersDetails { get; set; }
        
        private bool _IsBusy;
        public bool IsBusy
        {
            get { return _IsBusy; }
            set
            {
                _IsBusy = value;
                OnPropertyChanged();
            }
        }

        public OrderHistoryViewModel()
        {
            OrdersDetails = new ObservableCollection<OrderHistory>();
            LoadUserOrders();
        }

        private async void LoadUserOrders()
        {
            try
            {
                if (IsBusy) return;
                IsBusy = true;
                OrdersDetails.Clear();
                var service = new OrderHistoryService();
                var details = await service.GetOrderDetailsAsync();
                foreach (var order in details)
                {
                    OrdersDetails.Add(order);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erreur", ex.Message, "ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
