const toggleLoginPassword = document.getElementById('toggleLoginPassword');
const loginPasswordField = document.getElementById('loginPassword');
const eyeLoginIcon = document.getElementById('eyeLoginIcon');

// Mặc định icon sẽ là fa-eye-slash (đang che mật khẩu)
toggleLoginPassword.addEventListener('click', () => {
  const isHidden = loginPasswordField.type === 'password';
  loginPasswordField.type = isHidden ? 'text' : 'password';
  eyeLoginIcon.classList.toggle('fa-eye-slash'); // Đổi icon
  eyeLoginIcon.classList.toggle('fa-eye');
});
