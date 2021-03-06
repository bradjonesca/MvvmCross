// MvxComposeEmailTask.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using Android.Content;
using Cirrious.CrossCore.Droid.Platform;

namespace Cirrious.MvvmCross.Plugins.Email.Droid
{
    public class MvxComposeEmailTask
        : MvxAndroidTask
          , IMvxComposeEmailTask
    {
        public void ComposeEmail(string to, string cc, string subject, string body, bool isHtml)
        {
            var emailIntent = new Intent(global::Android.Content.Intent.ActionSend);

            var toList = new[] {to ?? string.Empty};
            var ccList = new[] {cc ?? string.Empty};
            ;

            emailIntent.PutExtra(global::Android.Content.Intent.ExtraEmail, toList);
            emailIntent.PutExtra(global::Android.Content.Intent.ExtraCc, ccList);

            emailIntent.PutExtra(global::Android.Content.Intent.ExtraSubject, subject ?? string.Empty);

            if (isHtml)
                emailIntent.SetType("text/html");
            else
                emailIntent.SetType("plain/text");

            emailIntent.PutExtra(global::Android.Content.Intent.ExtraText, body ?? string.Empty);

            StartActivity(emailIntent);
        }
    }
}