using _9_dars_uyga_vazifa.Models

namespace _9_dars_uyga_vazifa.Services;

public class PostService
{
    private List<Post> posts;

    public PostService()
    {
        posts = new List<Post>();
    }

    public Post AddPost(Post post)
    {
        post.Id = Guid.NewGuid();
        posts.Add(post);

        return post;
    }

    public Post GetPostById(Guid postId)
    {
        foreach (var post in posts)
        {
            if (post.Id==postId)
            {
                return post;
            }
        }
        return null;
    }
    public bool DeletePost(Guid postId)
    {
        var postDb = GetPostById(postId);
        if (postDb is null)
        {
            return false;
        }
        posts.Remove(postDb);
        return true;
    }
    public bool UpdatePost(Post updatPost)
    {
        var postDb = GetPostById(updatPost.Id);
        if (postDb is null)
        {
            return false;
        }
        var index = posts.IndexOf(postDb);
        posts[index] = updatPost;
        return true;
    }
    public List<Post> GetAllPosts()
    {
        return posts;
    }

    public Post GetMostViewedPost()
    {
        var mostViewedPost = new Post();
        var mostView = 0;
        foreach (var post in posts)
        {
            if (post.ViewerNames.Count>mostView)
            {
                mostView = post.ViewerNames.Count;
                mostViewedPost = post;
            }
        }
        return mostViewedPost;
    }

    public Post GetMostLikedPost()
    {
        Post mostLikeedPost = new Post();
        var mostLiked = 0;
        foreach (var post in posts)
        {
            if (post.QuantityLikes>mostLiked)
            {
                mostLiked = post.ViewerNames.Count;
                mostLikeedPost=post;
            }
        }
        return mostLikeedPost;
    }

    public Post GetMostCommentedPost()
    {
        Post mostCommentPost = new Post();
        var mostComment = 0;
        foreach (var post in posts)
        {
            if (post.Comments.Count>mostComment)
            {
                mostComment = post.Comments.Count;
                mostCommentPost = post;
            }
        }
        return mostCommentPost;
    }

    public List<Post> GetPostsByComment(string comment)
    {
        var mostComments = new List<Post>();
        foreach (var post in posts)
        {
            var comments = post.Comments;
            if (comment.Contains(comment) is true)
            {
                mostComments.Add(post);
            }
        }
        return mostComments;

    }

}

