using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Renewal.Application.Mappings
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile);
    }
}
