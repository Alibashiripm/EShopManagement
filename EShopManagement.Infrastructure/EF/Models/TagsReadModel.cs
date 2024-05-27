namespace EShopManagement.Infrastructure.EF.Models
{
    internal class TagsReadModel
    {
        public List<string> Tags { get; set; }

        public static TagsReadModel GetTags(string value)
        {
            List<string> splitTags = value.Split(',').ToList();
            return new TagsReadModel
            {
                Tags = splitTags
            };
        }

        public static string ConvertToString(TagsReadModel tagsReadModel)
        {
            return string.Join(",", tagsReadModel.Tags);
        }
    }
}
