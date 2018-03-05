using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.TVScripts.Models;

namespace Xamarin.TVScripts
{
    public interface IQuotes
    {
        List<Quote> GetQuotes();
    }
}
