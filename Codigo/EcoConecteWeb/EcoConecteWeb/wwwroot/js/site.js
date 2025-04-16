// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Quando o documento estiver pronto
$(document).ready(function() {
    
    // Máscara para campos de CEP
    $('.cep-input').on('input', function() {
        let value = $(this).val().replace(/\D/g, '');
        if (value.length > 5) {
            value = value.substring(0, 5) + '-' + value.substring(5, 8);
        }
        $(this).val(value);
    });
    
    // Inicialização de tooltips (se houver)
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
    if (tooltipTriggerList.length) {
        var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
            return new bootstrap.Tooltip(tooltipTriggerEl);
        });
    }
    
    // Inicialização de popovers (se houver)
    var popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'));
    if (popoverTriggerList.length) {
        var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
            return new bootstrap.Popover(popoverTriggerEl);
        });
    }
    
    // Feedback visual para botões de ação
    $('.action-btn').on('click', function() {
        $(this).addClass('clicked');
        setTimeout(function() {
            $('.action-btn').removeClass('clicked');
        }, 300);
    });
});
