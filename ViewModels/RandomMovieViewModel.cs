using System.Collections.Generic;
using VideoRental.Models;

namespace VideoRental.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movies Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}