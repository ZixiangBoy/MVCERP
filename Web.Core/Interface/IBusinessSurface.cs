using System;
using Web.Core.Enums;
using Web.Core.Cache;

namespace Web.Core.Interface
{
    public interface IBusinessSurface : IBaseSurface
    {
        ICache Cacher { get; }

        EnViewEditMode EditMode { get; set; }
    }
}

