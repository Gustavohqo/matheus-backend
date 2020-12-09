using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Siteware.Application.Dtos;

namespace Siteware.Application.Interfaces
{
    public interface ICartAppService
    {
        CartDto Get(int id);
    }
}
