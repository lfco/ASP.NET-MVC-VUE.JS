namespace Common.ProjectHelpers
{
    public static class Slug
    {
        public static string Course(int id, string slug)
        {
            return string.Format(
                "course/{0}/{1}", id, slug.ToLower()
            );
        }

        public static string Category(int id, string slug)
        {
            return string.Format(
                "category/{0}/{1}", id, slug.ToLower()
            );
        }
    }
}
