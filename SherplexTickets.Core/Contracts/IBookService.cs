﻿using SherplexTickets.Core.ViewModels.BookView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherplexTickets.Core.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<BookAllViewModel>> AllAsync();
    }
}