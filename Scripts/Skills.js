// Skills Page Interactive Progress Bars
document.addEventListener('DOMContentLoaded', function () {

    // Initialize skills animation
    initializeSkillsAnimation();

    // Setup intersection observer for scroll-triggered animations
    setupScrollAnimations();

    // Add interactive hover effects
    addInteractiveEffects();

    function initializeSkillsAnimation() {
        const progressBars = document.querySelectorAll('.progress-bar');

        progressBars.forEach((bar, index) => {
            // Get the skill level from the aria-valuenow attribute
            const skillLevel = bar.getAttribute('aria-valuenow');

            if (skillLevel) {
                // Set CSS custom property for animation
                bar.style.setProperty('--skill-level', skillLevel + '%');
                bar.setAttribute('data-skill-level', skillLevel);

                // Add staggered animation delay
                setTimeout(() => {
                    animateProgressBar(bar, skillLevel);
                }, index * 200 + 1000); // Start after 1s, stagger by 200ms
            }
        });
    }

    function animateProgressBar(progressBar, targetLevel) {
        // Reset width
        progressBar.style.width = '0%';

        // Animate to target level
        setTimeout(() => {
            progressBar.style.transition = 'width 2.5s cubic-bezier(0.4, 0, 0.2, 1)';
            progressBar.style.width = targetLevel + '%';

            // Add completion effect
            setTimeout(() => {
                progressBar.classList.add('animation-complete');
                addCompletionEffect(progressBar);
            }, 2500);
        }, 100);
    }

    function addCompletionEffect(progressBar) {
        // Create a pulse effect when animation completes
        progressBar.style.boxShadow = `
            0 0 20px rgba(220, 38, 38, 0.6),
            0 0 40px rgba(220, 38, 38, 0.3),
            inset 0 0 20px rgba(255, 255, 255, 0.1)
        `;

        setTimeout(() => {
            progressBar.style.boxShadow = '';
        }, 1000);
    }

    function setupScrollAnimations() {
        // Create intersection observer for scroll-triggered animations
        const observerOptions = {
            threshold: 0.3,
            rootMargin: '0px 0px -100px 0px'
        };

        const skillsObserver = new IntersectionObserver((entries) => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    entry.target.classList.add('animate');

                    // Re-animate progress bars when scrolled back into view
                    const progressBar = entry.target.querySelector('.progress-bar');
                    if (progressBar && !progressBar.classList.contains('animation-complete')) {
                        const skillLevel = progressBar.getAttribute('aria-valuenow');
                        if (skillLevel) {
                            animateProgressBar(progressBar, skillLevel);
                        }
                    }
                }
            });
        }, observerOptions);

        // Observe all skill items
        document.querySelectorAll('.col-md-6').forEach(skill => {
            skillsObserver.observe(skill);
        });
    }

    function addInteractiveEffects() {
        const skillItems = document.querySelectorAll('.mb-3');

        skillItems.forEach(item => {
            const progressBar = item.querySelector('.progress-bar');
            const label = item.querySelector('.form-label');

            // Enhanced hover effects
            item.addEventListener('mouseenter', () => {
                // Add dynamic glow
                progressBar.style.filter = 'brightness(1.1) contrast(1.1)';

                // Animate skill label
                label.style.transform = 'translateX(5px)';
                label.style.color = '#dc2626';

                // Add particle effect
                createHoverParticles(item);
            });

            item.addEventListener('mouseleave', () => {
                progressBar.style.filter = '';
                label.style.transform = '';
                label.style.color = '';

                // Remove particles
                removeHoverParticles(item);
            });

            // Click effect for mobile
            item.addEventListener('click', () => {
                createClickRipple(item, event);
            });
        });
    }

    function createHoverParticles(container) {
        // Create subtle floating particles on hover
        const particles = [];

        for (let i = 0; i < 3; i++) {
            const particle = document.createElement('div');
            particle.className = 'hover-particle';
            particle.style.cssText = `
                position: absolute;
                width: 3px;
                height: 3px;
                background: rgba(220, 38, 38, 0.6);
                border-radius: 50%;
                pointer-events: none;
                z-index: 100;
                top: ${Math.random() * 100}%;
                left: ${Math.random() * 100}%;
                animation: particleFloat 2s ease-in-out infinite;
                animation-delay: ${i * 0.3}s;
            `;

            container.appendChild(particle);
            particles.push(particle);
        }

        container._hoverParticles = particles;
    }

    function removeHoverParticles(container) {
        if (container._hoverParticles) {
            container._hoverParticles.forEach(particle => {
                particle.style.animation = 'particleFloat 0.5s ease-out forwards';
                setTimeout(() => {
                    if (particle.parentNode) {
                        particle.parentNode.removeChild(particle);
                    }
                }, 500);
            });
            container._hoverParticles = null;
        }
    }

    function createClickRipple(container, event) {
        const ripple = document.createElement('div');
        const rect = container.getBoundingClientRect();
        const x = event ? (event.clientX - rect.left) : rect.width / 2;
        const y = event ? (event.clientY - rect.top) : rect.height / 2;

        ripple.style.cssText = `
            position: absolute;
            width: 0;
            height: 0;
            border-radius: 50%;
            background: rgba(220, 38, 38, 0.3);
            pointer-events: none;
            z-index: 99;
            left: ${x}px;
            top: ${y}px;
            transform: translate(-50%, -50%);
            animation: rippleEffect 0.8s ease-out forwards;
        `;

        container.appendChild(ripple);

        setTimeout(() => {
            if (ripple.parentNode) {
                ripple.parentNode.removeChild(ripple);
            }
        }, 800);
    }

    // Add dynamic CSS animations
    const style = document.createElement('style');
    style.textContent = `
        @keyframes particleFloat {
            0%, 100% {
                opacity: 0;
                transform: translateY(0) scale(1);
            }
            25% {
                opacity: 1;
            }
            50% {
                opacity: 0.8;
                transform: translateY(-20px) scale(1.2);
            }
            75% {
                opacity: 1;
            }
        }
        
        @keyframes rippleEffect {
            to {
                width: 300px;
                height: 300px;
                opacity: 0;
            }
        }
        
        .skill-item-enhanced {
            transform: translateY(-2px) scale(1.02);
            transition: all 0.3s cubic-bezier(0.4, 0, 0.2, 1);
        }
        
        .progress-bar.pulsing {
            animation: progressPulse 1s ease-in-out infinite;
        }
    `;

    document.head.appendChild(style);

    // Performance optimization: Debounce scroll events
    let scrollTimeout;
    window.addEventListener('scroll', () => {
        clearTimeout(scrollTimeout);
        scrollTimeout = setTimeout(() => {
            // Update progress bar animations based on scroll position
            updateProgressBarsOnScroll();
        }, 100);
    });

    function updateProgressBarsOnScroll() {
        const skillsSection = document.querySelector('.skills-section');
        if (!skillsSection) return;

        const rect = skillsSection.getBoundingClientRect();
        const isVisible = rect.top < window.innerHeight && rect.bottom > 0;

        if (isVisible) {
            const progressBars = skillsSection.querySelectorAll('.progress-bar');
            progressBars.forEach(bar => {
                if (!bar.classList.contains('scroll-animated')) {
                    bar.classList.add('scroll-animated');
                    // Add subtle pulse effect
                    bar.style.animation += ', progressPulse 2s ease-in-out 3';
                }
            });
        }
    }

    // Initialize skill counters (number animation)
    function animateSkillCounters() {
        const progressBars = document.querySelectorAll('.progress-bar');

        progressBars.forEach(bar => {
            const targetValue = parseInt(bar.getAttribute('aria-valuenow'));
            const duration = 2000; // 2 seconds
            const startTime = performance.now();

            function updateCounter(currentTime) {
                const elapsed = currentTime - startTime;
                const progress = Math.min(elapsed / duration, 1);

                // Use easing function
                const easedProgress = easeOutCubic(progress);
                const currentValue = Math.floor(targetValue * easedProgress);

                bar.textContent = currentValue + '%';

                if (progress < 1) {
                    requestAnimationFrame(updateCounter);
                }
            }

            requestAnimationFrame(updateCounter);
        });
    }

    function easeOutCubic(t) {
        return 1 - Math.pow(1 - t, 3);
    }

    // Start counter animation after a delay
    setTimeout(animateSkillCounters, 1200);

    // Add keyboard navigation support
    document.addEventListener('keydown', (event) => {
        if (event.key === 'Tab') {
            const focusedElement = document.activeElement;
            if (focusedElement.classList.contains('mb-3')) {
                focusedElement.style.transform = 'translateY(-3px)';
                focusedElement.style.boxShadow = '0 8px 25px rgba(220, 38, 38, 0.3)';
            }
        }
    });

    document.addEventListener('keyup', (event) => {
        if (event.key === 'Tab') {
            const prevFocused = document.querySelectorAll('.mb-3');
            prevFocused.forEach(item => {
                if (item !== document.activeElement) {
                    item.style.transform = '';
                    item.style.boxShadow = '';
                }
            });
        }
    });

    console.log('Skills page interactive features initialized successfully!');
});

// Utility function to refresh animations (can be called externally)
window.refreshSkillsAnimations = function () {
    document.querySelectorAll('.progress-bar').forEach(bar => {
        bar.classList.remove('animation-complete');
        bar.style.width = '0%';

        const skillLevel = bar.getAttribute('aria-valuenow');
        if (skillLevel) {
            setTimeout(() => {
                bar.style.width = skillLevel + '%';
            }, 100);
        }
    });
};