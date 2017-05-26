let upVote = (postId) => {
    let _data = {
        id: postId
    }

    $.ajax({
        url: "/vote/up",
        data: JSON.stringify(_data),
        contentType: "application/json",
        type: "POST",
        dataType: "html",
        success: (newHtml) => {
            $("#voteContainer-" + postId).html(newHtml);
        }
    })
}

let downVote = (postId) => {
    let _data = {
        id: postId
    }

    $.ajax({
        url: "/vote/down",
        data: JSON.stringify({ id: postId }),
        contentType: "application/json",
        type: "POST",
        dataType: "html",
        success: (newHtml) => {
            $("#voteContainer-" + postId).html(newHtml);
        }
    })
}


