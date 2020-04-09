function showRating(classes) {
    var stars_elements = document.getElementsByClassName(classes);

    for (let a = 0; a < stars_elements.length; a++) {
        let rating_number = stars_elements[a].querySelector("div").textContent;

        rating_number = rating_number.replace("(", "");
        rating_number = rating_number.replace(")", "");

        let stars = stars_elements[a].getElementsByTagName("i");

        // Algorithm
        let counter = 0;

        while (rating_number >= 1) {
            stars[counter].className = "fa fa-star";
            counter++;
            rating_number--;
        }

        if (rating_number >= 0.5) {
            stars[counter].className = "fas fa-star-half-alt";
        }
    }
}

showRating("stars_ratings");

function sendRating(projectId, rating) {
    var token = $("#starRatingsForm input[name='__RequestVerificationToken']").val();
    var json = { projectId: projectId, rating: rating };

    $.ajax({
        url: "/api/ratings",
        type: "POST",
        data: JSON.stringify(json),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: { 'X-CSRF-TOKEN': token },
        success: function (data) {       
            // Update Ratings on all divs
            let elements = document.getElementsByClassName("project_" + projectId);
            for (let a = 0; a < elements.length; a++) {
                let votes = elements[a].querySelector(".starRatingsSum");
                votes.innerHTML = "(" + data.rating + ")";
            }

            showRating("project_" + projectId);
        },
    });
}