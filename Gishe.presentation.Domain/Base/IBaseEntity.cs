using System;
using System.Collections.Generic;
using System.Text;

namespace Gishe.presentation.Domain.Base
{
    public interface IBaseEntity<TKey>
    {
        public TKey Id { get; }
    }
}
