using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanpooshStore.Application.Services.Products.Queries.GetSiteProductService
{
    public enum GetSiteProductOrdering
    {
        NotOrdered=0,
        /// <summary>
        /// پربازدیدترین
        /// </summary>
        MostVisited = 1,
        /// <summary>
        /// پرفروشترین
        /// </summary>
        MostPaid = 2,
        /// <summary>
        /// محبوب ترین
        /// </summary>
        MostWished = 3,
        /// <summary>
        /// جدیدترین
        /// </summary>
        MostNew = 4,
        /// <summary>
        /// گرانترین
        /// </summary>
        MostExpensive = 5,
        /// <summary>
        /// ارزانترین
        /// </summary>
        MostCheap = 6,

    }
}
