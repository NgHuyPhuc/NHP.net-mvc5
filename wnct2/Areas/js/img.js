function changeImage(id){
    let imagePath = document.getElementById(id).getAttribute('src');
    document.getElementById('modal__img-big').setAttribute('src', imagePath);
    }
