const toggleSignupPassword = document.getElementById('toggleSignupPassword');
const signupPasswordField = document.getElementById('signupPassword');
const eyeSignupIcon = document.getElementById('eyeSignupIcon');

toggleSignupPassword.addEventListener('click', () => {
  const isHidden = signupPasswordField.type === 'password';
  signupPasswordField.type = isHidden ? 'text' : 'password';
  eyeSignupIcon.classList.toggle('fa-eye-slash'); // Đổi icon
  eyeSignupIcon.classList.toggle('fa-eye');
});

const toggleConfirmPassword = document.getElementById('toggleConfirmPassword');
const confirmPasswordField = document.getElementById('confirmPassword');
const eyeConfirmIcon = document.getElementById('eyeConfirmIcon');

toggleConfirmPassword.addEventListener('click', () => {
  const isHidden = confirmPasswordField.type === 'password';
  confirmPasswordField.type = isHidden ? 'text' : 'password';
  eyeConfirmIcon.classList.toggle('fa-eye-slash'); // Đổi icon
  eyeConfirmIcon.classList.toggle('fa-eye');
});
