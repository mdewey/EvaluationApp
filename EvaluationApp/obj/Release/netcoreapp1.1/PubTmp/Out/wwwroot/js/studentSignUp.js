// Submit form with id function.
function submit_by_id() {
    var name = document.getElementById("name").value;
    if (validation()) // Calling validation function
    {
        document.getElementById("form_id").submit(); //form submission
        alert(" Name : " + name + " \n Form Id : " + document.getElementById("form_id").getAttribute("id") + "\n\n Form Submitted Successfully......");
    }
}