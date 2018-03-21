


document.querySelector(".comment-del").addEventListener("click", function(event) {


    if (event.target.tagName === "I" || event.target.tagName === "BUTTON") {

        var id = event.target.tagName === "I"
            ? event.target.parentNode.parentNode.id
            : event.target.parentNode.id;

        var el = document.getElementById(id);

        var con = el.parentNode.removeChild(el);

        if (con) {

            $(document).ready(function() {

                $.ajax({
                    url: "/api/delete/" + id,
                    method: "DELETE",
                    success: function() {

                        console.log("deleted");
                    }
            });

            });
        }

    }

});