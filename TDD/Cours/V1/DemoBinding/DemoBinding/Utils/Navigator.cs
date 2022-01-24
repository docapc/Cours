﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using DemonBinding.Models;

namespace DemoBinding.Utils
{
    public class Navigator : ObservableObject, INavigator
    {
        private List<Control> Views { get; set; } = new List<Control>();

        private ContentControl currentContentControl;

        public Stack<Control> BackStack { get; set; } = new Stack<Control>(); 

        public ContentControl CurrentContentControl
        {
            get => currentContentControl;
            set
            {
                currentContentControl = value;
                OnNotifyPropertyChanged();
            }
        }

        public void RegisterView(Control view)
        {
            Views.Add(view);
        }
        
        public void NavigateTo(Type type)
        {
            if(CurrentContentControl == null) return;
            var view = Views.SingleOrDefault(elt => elt.GetType() == type);
            if (view == null) return;
            BackStack.Push(view);
            CurrentContentControl.Content = view;
        }



        public void Back()
        {
            if (CurrentContentControl == null) return;
            CurrentContentControl.Content = BackStack.Pop(); 
        }

        public bool CanGoBack()
        {
            return BackStack.TryPeek(out var result);
        }
    }
}
