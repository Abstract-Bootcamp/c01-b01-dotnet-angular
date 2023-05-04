function changeHeaderBackgroundColor() {
    let color = document.getElementById("color-picker").value;

    console.log(color);

    //get header element
    let header = document.getElementById("header");

    //change background color
    header.style.backgroundColor = color;
}
