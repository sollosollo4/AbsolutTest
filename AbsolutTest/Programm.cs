using AbsolutTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsolutTest
{
    public static class Programm
    {
        public static async Task Main(string[] args)
        {
            Customer volodya = new Customer()
            {
                Age = 20,
                AliveAddress = "москва",
                Email = "Эмайл володи",
                FullName = "Володя Красивый",
                RegisterAddress = "москва",
                TelephoneNumber = "телефон володи",
            };

            ViewModel.CustomerViewModel viewModel = new ViewModel.CustomerViewModel();
            await viewModel.SaveCustomer(volodya);
            // Володя меняет имя. 
            /// CustomerViewModel.UpdateCustomerInfo()
            volodya.FullName = "Володя Умный";
            await viewModel.UpdateCustomerInfo(volodya);
            // Володя переезжает в воронеж и меняет прописку. 
            /// CustomerViewModel.SaveAddress()
            var newAlvieAddress = "Воронеж";
            var newRegisterAddress = "Воронеж";
            await viewModel.SaveAddress(volodya.Id, newRegisterAddress, newAlvieAddress);
            // Володя купил себе документы
            /// CustomerViewModel.SaveDocs()
            Document documentO = new Document()
            {
                Number = "123456789",
                Seria = "123456789",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };
            await viewModel.SaveDocs(volodya.Id, documentO);
        }
    }
}
