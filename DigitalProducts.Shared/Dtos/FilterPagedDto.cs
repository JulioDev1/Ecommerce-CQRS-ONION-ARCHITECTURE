﻿namespace DigitalProducts.Shared.Dtos
{
    public class FilterPagedDto
    {
        public FilterProductDto FilterProductDto { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
