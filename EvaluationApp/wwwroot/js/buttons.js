let upVote = (lectureId, studentId) => {
    let _data = {
        LecturesId: lectureId,
        StudentsId: studentId
    }

    $.ajax({
        url: "/DataOfUnderstandings/Up",
        data: JSON.stringify(_data),
        contentType: "application/json",
        type: "POST",
        dataType: "json",
        success: (dataFromServer) => {
            console.log("success", dataFromServer);
        }
    })
}

let downVote = (lectureId, studentId) => {
    let _data = {
        LecturesId: lectureId,
        StudentsId: studentId
    }

    $.ajax({
        url: "/DataOfUnderstandings/Down",
        data: JSON.stringify(_data),
        contentType: "application/json",
        type: "POST",
        dataType: "json",
        success: (dataFromServer) => {
            console.log("success", dataFromServer);
        }
    })
}


