namespace ThinkLand.Mappers
{
    public static class ModelEntityMapper
    {
        public static DTO.Product ToEntity(this Model.Product product)
        {
            return new DTO.Product
            (
                stock: product.Stock,
                categoryid: product.CategoryID,
                name: product.Name,
                price: product.Price  
            );
        }
        
        public static DTO.Category ToEntity(this Model.Category category)
        {
            return new DTO.Category
            (      
                name: category.Name       
            );
        }
    }

}