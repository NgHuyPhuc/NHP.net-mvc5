

        const buyBtns = document.querySelectorAll('.js-product-details')
        const modal = document.querySelector('.js-modal')
        const modalClose = document.querySelector('.js-modal-close')
        const modalContainer = document.querySelector('.js-modal-container')
        

        function showProductDetails(){
            modal.classList.add('open')
        }
        

        function hideProductDetails(){
            modal.classList.remove('open')
        }
        

        for(const buyBtn of buyBtns){
            buyBtn.addEventListener('click', showProductDetails)
        }


        modalClose.addEventListener('click', hideProductDetails)
        modal.addEventListener('click', hideProductDetails)
        modalContainer.addEventListener('click', function(event) {
            event.stopPropagation()
        })



    

        $(document).ready(function() {
            $(window).scroll(function() {
                if($(this).scrollTop()){
                    $('#backtop').fadeIn();
                }else{
                    $('#backtop').fadeOut();
                }
            });
            $('#backtop').click(function(){
                $('html, body').animate({
                    scrollTop: 0
                }, 500);
            });
        });


    