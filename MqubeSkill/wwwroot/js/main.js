function openTestimonial(img, name, role, text) {

    // Set values inside modal
    document.getElementById("modalImg").src = img;
    document.getElementById("modalName").innerText = name;
    document.getElementById("modalPlace").innerText = role;
    document.getElementById("modalText").innerText = text;

    // Open Bootstrap modal
    var modal = new bootstrap.Modal(document.getElementById('testimonialModal'));
    modal.show();
}

function closeTestimonial() {
    var modalElement = document.getElementById('testimonialModal');
    var modalInstance = bootstrap.Modal.getInstance(modalElement);
    if (modalInstance) {
        modalInstance.hide();
    }
}
