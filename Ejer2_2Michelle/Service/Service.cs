using Ejer2_2Michelle.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ejer2_2Michelle.Service
{
    public class Service
    {
        public async Task<bool> saveSignatures(firma signature)
        {
            var result = await App.DBase.insertUpdateSignature(signature);

            return (result > 0);

        }


        public async Task<List<firma>> GetSignatures()
        {
            return await App.DBase.getListSignature();
        }


    }
}
