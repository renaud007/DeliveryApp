using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DeliveryApp.Behaviors
{
   public class NotNullBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += Bindable_TextChanged;
        }

        private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
         var entry = sender as Entry;
            entry.BackgroundColor = entry.Text.Length > 0 ? Color.Default : Color.Red;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);  
            
            bindable.TextChanged -= Bindable_TextChanged;
        }
    }
}
