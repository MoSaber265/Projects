document.addEventListener("DOMContentLoaded", function () {

    // ==========================================
    // 1. Page Transition Effect (انتقال سلس بين الصفحات)
    // ==========================================
    document.body.classList.add("page-enter");
    setTimeout(() => document.body.classList.add("page-visible"), 10);

    document.querySelectorAll("a[href]").forEach(function (link) {
        const href = link.getAttribute("href");
        if (!href || href.startsWith("http") || href.startsWith("#") || href.startsWith("mailto")) return;

        link.addEventListener("click", function (e) {
            e.preventDefault();
            document.body.classList.remove("page-visible");
            document.body.classList.add("page-exit");
            setTimeout(() => { window.location.href = href; }, 350);
        });
    });


    // ==========================================
    // 2. Hamburger Menu - يشتغل في كل الصفحات
    // ==========================================
    const menuBtn  = document.getElementById("menuBtn");
    const navLinks = document.getElementById("navLinks");

    if (menuBtn && navLinks) {
        menuBtn.addEventListener("click", function () {
            navLinks.classList.toggle("show");
            const isOpen = navLinks.classList.contains("show");
            menuBtn.innerHTML = isOpen ? "✕" : "☰";
            menuBtn.style.transition = "transform 0.3s ease";
            menuBtn.style.transform  = isOpen ? "rotate(90deg)" : "rotate(0deg)";
        });

        // إغلاق المنيو عند الضغط خارجه
        document.addEventListener("click", function (e) {
            if (!menuBtn.contains(e.target) && !navLinks.contains(e.target)) {
                navLinks.classList.remove("show");
                menuBtn.innerHTML = "☰";
                menuBtn.style.transform = "rotate(0deg)";
            }
        });

        // إغلاق المنيو عند تكبير الشاشة
        window.addEventListener("resize", function () {
            if (window.innerWidth > 768) {
                navLinks.classList.remove("show");
                menuBtn.innerHTML = "☰";
                menuBtn.style.transform = "rotate(0deg)";
            }
        });
    }


    // ==========================================
    // 3. Register Page Logic
    // ==========================================
    const registerForm = document.getElementById("registerForm");

    if (registerForm) {
        const checkbox  = registerForm.querySelector("#termsCheckbox");
        const submitBtn = registerForm.querySelector("#submitBtn");

        if (checkbox && submitBtn) {
            checkbox.addEventListener("change", function () {
                submitBtn.classList.toggle("disabled", !checkbox.checked);
                submitBtn.disabled = !checkbox.checked;
            });
        }

        registerForm.addEventListener("submit", function (e) {
            e.preventDefault();
            if (submitBtn && !submitBtn.disabled) {
                window.location.href = "product1.html";
            }
        });
    }


    // ==========================================
    // 4. Login Page Validation
    // ==========================================
    const loginForm = document.getElementById("loginForm");

    if (loginForm) {
        const emailInput      = loginForm.querySelector("#email");
        const passwordInput   = loginForm.querySelector("#password");
        const emailWrapper    = loginForm.querySelector("#emailWrapper");
        const passwordWrapper = loginForm.querySelector("#passwordWrapper");
        const emailError      = loginForm.querySelector("#emailError");
        const passwordError   = loginForm.querySelector("#passwordError");

        loginForm.addEventListener("submit", function (e) {
            e.preventDefault();

            const emailValue    = emailInput    ? emailInput.value.trim()    : "";
            const passwordValue = passwordInput ? passwordInput.value.trim() : "";
            let isValid = true;

            if (emailValue === "") {
                showError(emailError, emailWrapper, "يرجى إدخال البريد الإلكتروني أو الهاتف.");
                isValid = false;
            } else if (isNaN(emailValue) && !emailValue.includes("@")) {
                showError(emailError, emailWrapper, "يرجى إدخال بريد إلكتروني صحيح يحتوي على @ أو رقم هاتف.");
                isValid = false;
            } else {
                clearError(emailError, emailWrapper);
            }

            if (passwordValue === "") {
                showError(passwordError, passwordWrapper, "يرجى إدخال كلمة المرور.");
                isValid = false;
            } else if (passwordValue.length < 6) {
                showError(passwordError, passwordWrapper, "كلمة المرور 6 أحرف على الأقل.");
                isValid = false;
            } else {
                clearError(passwordError, passwordWrapper);
            }

            if (isValid) window.location.href = "product1.html";
        });

        if (emailInput)    emailInput.addEventListener("input",    () => clearError(emailError, emailWrapper));
        if (passwordInput) passwordInput.addEventListener("input", () => clearError(passwordError, passwordWrapper));
    }

    function showError(errorEl, wrapperEl, msg) {
        if (errorEl)   { errorEl.textContent = msg; errorEl.style.display = "block"; }
        if (wrapperEl) wrapperEl.classList.add("error-border");
    }
    function clearError(errorEl, wrapperEl) {
        if (errorEl)   errorEl.style.display = "none";
        if (wrapperEl) wrapperEl.classList.remove("error-border");
    }


    // ==========================================
    // 5. Cart Plus / Minus
    // ==========================================
    const totalPriceEl = document.getElementById("total-price");

    function updateTotal() {
        let total = 0;
        document.querySelectorAll(".cart-item").forEach(function (item) {
            const quantityEl = item.querySelector(".quantity");
            const priceEl    = item.querySelector(".item-price");
            if (!quantityEl || !priceEl) return;
            const qty       = Number(quantityEl.textContent);
            const basePrice = Number(priceEl.dataset.price);
            priceEl.textContent = "$" + (qty * basePrice);
            total += qty * basePrice;
        });
        if (totalPriceEl) totalPriceEl.textContent = "$" + total;
    }

    document.querySelectorAll(".plus").forEach(btn => {
        btn.addEventListener("click", function () {
            const qty = btn.parentElement.querySelector(".quantity");
            qty.textContent = Number(qty.textContent) + 1;
            updateTotal();
        });
    });

    document.querySelectorAll(".minus").forEach(btn => {
        btn.addEventListener("click", function () {
            const qty = btn.parentElement.querySelector(".quantity");
            if (Number(qty.textContent) > 0) {
                qty.textContent = Number(qty.textContent) - 1;
                updateTotal();
            }
        });
    });


    // ==========================================
    // 6. زرار الدفع الذكي
    // ==========================================
    const paymentBtn = document.getElementById("paymentBtn");

    if (paymentBtn) {
        paymentBtn.addEventListener("click", function () {
            const currentTotal = totalPriceEl ? Number(totalPriceEl.textContent.replace("$", "")) : 0;
            if (currentTotal > 0) {
                window.location.href = "checkout.html";
            } else {
                showToast("يجب إضافة عطر واحد على الأقل قبل الدفع!");
            }
        });
    }


    // ==========================================
    // 7. Toast Notification (رسالة أنيقة بدل alert)
    // ==========================================
    function showToast(message) {
        const old = document.getElementById("luxury-toast");
        if (old) old.remove();

        const toast = document.createElement("div");
        toast.id = "luxury-toast";
        toast.textContent = message;
        toast.style.cssText = `
            position: fixed;
            bottom: 30px;
            left: 50%;
            transform: translateX(-50%) translateY(20px);
            background: rgba(15,15,15,0.96);
            border: 1px solid #d4af37;
            color: #d4af37;
            padding: 14px 32px;
            border-radius: 50px;
            font-family: 'Amiri', serif;
            font-size: 18px;
            z-index: 9999;
            opacity: 0;
            transition: all 0.4s ease;
            backdrop-filter: blur(12px);
            box-shadow: 0 8px 32px rgba(0,0,0,0.6);
            white-space: nowrap;
            pointer-events: none;
        `;
        document.body.appendChild(toast);

        setTimeout(() => {
            toast.style.opacity = "1";
            toast.style.transform = "translateX(-50%) translateY(0)";
        }, 10);

        setTimeout(() => {
            toast.style.opacity = "0";
            toast.style.transform = "translateX(-50%) translateY(20px)";
            setTimeout(() => toast.remove(), 400);
        }, 3000);
    }


    // ==========================================
    // 8. Scroll Reveal Animation
    // ==========================================
    const revealEls = document.querySelectorAll(
        ".product-card, .cart-item, .contact-item, .login-card, .checkout-form, .category-title, .closing-message, .action-buttons"
    );

    if (revealEls.length > 0 && "IntersectionObserver" in window) {
        const observer = new IntersectionObserver(function (entries) {
            entries.forEach(function (entry, i) {
                if (entry.isIntersecting) {
                    setTimeout(() => entry.target.classList.add("revealed"), i * 100);
                    observer.unobserve(entry.target);
                }
            });
        }, { threshold: 0.1 });

        revealEls.forEach(el => {
            el.classList.add("reveal-hidden");
            observer.observe(el);
        });
    }


    // ==========================================
    // 9. Product Image 3D Parallax
    // ==========================================
    const productImg = document.querySelector(".product-img");
    if (productImg) {
        document.addEventListener("mousemove", function (e) {
            const x = (e.clientX / window.innerWidth  - 0.5) * 14;
            const y = (e.clientY / window.innerHeight - 0.5) * 14;
            productImg.style.transition = "transform 0.1s ease";
            productImg.style.transform  = `perspective(900px) rotateY(${x}deg) rotateX(${-y}deg) scale(1.03)`;
        });

        document.addEventListener("mouseleave", function () {
            productImg.style.transition = "transform 0.5s ease";
            productImg.style.transform  = "perspective(900px) rotateY(0deg) rotateX(0deg) scale(1)";
        });
    }


    // ==========================================
    // 10. Dots navigation (اضغط على الـ dot للتنقل)
    // ==========================================
    const dots = document.querySelectorAll(".dot");
    const dotPages = ["product1.html", "product2.html", "product3.html"];

    dots.forEach(function (dot, index) {
        dot.style.cursor = "pointer";
        dot.addEventListener("click", function () {
            if (!dot.classList.contains("active")) {
                document.body.classList.add("page-exit");
                setTimeout(() => { window.location.href = dotPages[index]; }, 350);
            }
        });
    });

});