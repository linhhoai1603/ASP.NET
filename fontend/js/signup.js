// Toggle Password Visibility
function togglePassword(inputId) {
  const input = document.getElementById(inputId);
  const icon = document.querySelector(`#${inputId} + i`);
  
  // Toggle the type attribute
  input.type = input.type === 'password' ? 'text' : 'password';
  
  // Change icon based on visibility
  icon.classList.toggle('fa-eye');
  icon.classList.toggle('fa-eye-slash');
}

// Handle Register
function handleRegister(event) {
  event.preventDefault();
  
  const phone = document.getElementById('register-phone').value;
  const password = document.getElementById('register-password').value;
  const confirmPassword = document.getElementById('confirm-password').value;
  const otp = document.getElementById('register-otp').value;

  if (password !== confirmPassword) {
      alert('Mật khẩu không khớp!');
      return;
  }

  if (!otp) {
      alert('Vui lòng nhập mã OTP.');
      return;
  }

  console.log('Registering with:', { phone, password, otp });
  alert('Đăng ký thành công!');
}

// Request OTP
function requestOtp() {
  const phone = document.getElementById('register-phone').value;

  if (!phone) {
      alert('Vui lòng nhập số điện thoại.');
      return;
  }

  console.log('Requesting OTP for phone:', phone);
  alert('Mã OTP đã được gửi tới số điện thoại của bạn.');
}
