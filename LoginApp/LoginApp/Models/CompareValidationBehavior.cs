using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LoginUser.Models
{
        public class CompareValidationBehavior : Behavior<Entry>
        {
        [Obsolete]
        public static BindableProperty TextProperty = BindableProperty.Create<CompareValidationBehavior, string>(tc => tc.Text, string.Empty, BindingMode.TwoWay);
            static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(CompareValidationBehavior), false);

            public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

            public bool IsValid
            {
                get { return (bool)base.GetValue(IsValidProperty); }
                private set { base.SetValue(IsValidPropertyKey, value); }
            }

        [Obsolete]
        public string Text
            {
                get
                {
                    return (string)GetValue(TextProperty);
                }
                set
                {
                    SetValue(TextProperty, value);
                }
            }

        [Obsolete]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
        protected override void OnAttachedTo(Entry bindable)
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member
        {
                bindable.TextChanged += HandleTextChanged;
                base.OnAttachedTo(bindable);
            }

        [Obsolete]
        void HandleTextChanged(object sender, TextChangedEventArgs e)
            {
                IsValid = e.NewTextValue == Text;

                ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
            }

        [Obsolete]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
        protected override void OnDetachingFrom(Entry bindable)
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member
        {
                bindable.TextChanged -= HandleTextChanged;
                base.OnDetachingFrom(bindable);
            }
        }
}
