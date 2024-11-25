using CRUD_Post.Models;

namespace CRUD_Post.Service;

public class PostContentService
{
    private List<PostContent> postContent;
    public PostContentService()
    {
        var postContent = new PostContent();
    }
    public PostContent AddedPost(PostContent added)
    {
        var id = Guid.NewGuid();
        postContent.Add(added);
        return added;
    }
    public bool DeletePostContent(Guid postId)
    {
        var TF = false;
        foreach (var post in postContent)
        {
            if (post.Id == postId)
            {
                postContent.Remove(post);
                TF = true;
                break;
            }
        }
        return TF;
    }

    public bool UpdatePost(PostContent updatePost)
    {
        var TF = false;
        for (var i = 0; i < postContent.Count; i++)
        {
            if (postContent[i].Id == updatePost.Id)
            {
                postContent[i] = updatePost;
                TF = true;
            }
        }
        return TF;
    }
    public PostContent GetById(Guid postId)
    {
        foreach (var post in postContent)
        {
            if (post.Id == postId)
            {
                return post;
            }
        }
        return null;
    }
    public List<PostContent> GetAllPost()
    {
        return postContent;
    }

    public PostContent GetMostViewedPost()
    {
        var responsePost = new PostContent();
        foreach (var post in postContent)
        {
            if (post.ViewerNames.Count > responsePost.ViewerNames.Count)
            {
                responsePost = post;
            }
        }
        return responsePost;
    }
    public PostContent GetMostLikedPost()
    {
        var responsePost = new PostContent();
        foreach (var post in postContent)
        {
            if (post.QuantityLikes > responsePost.QuantityLikes)
            {
                responsePost = post;
            }
        }
        return responsePost;
    }
    public PostContent GetMostCommentedPost()
    {
        var maxCountComment = new PostContent();
        foreach (var post in postContent)
        {
            if (post.Comments.Count > maxCountComment.Comments.Count)
            {
                maxCountComment = post;
            }
        }
        return maxCountComment;
    }
    public List<PostContent> GetPostsByComment(string comment)
    {
        var responsePosts = new List<PostContent>();
        foreach (var post in postContent)
        {
            if (post.Comments.Contains(comment) is true)
            {
                responsePosts.Add(post);
            }
        }
        return responsePosts;
    }
    public bool AddCommentToPost(Guid postId, string comment)
    {
        var post = GetById(postId);
        if (post is null)
        {
            return false;
        }
        post.Comments.Add(comment);
        return true;
    }
    public bool AddViewerNameToPost(Guid postId, string viewerName)
    {
        var post = GetById(postId);
        if (post is null)
        {
            return false;
        }
        post.ViewerNames.Add(viewerName);
        return true;
    }
    public bool AddLikesToPost(Guid postId)
    {
        var post = GetById(postId);
        if (post is null)
        {
            return false;
        }
        post.QuantityLikes++;
        return true;
    }
}


//GetMostCommentedPost
//GetPostsByComment